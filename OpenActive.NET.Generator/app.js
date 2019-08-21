const DATA_MODEL_OUTPUT_DIR = "../OpenActive.NET/";
const DATA_MODEL_DOCS_URL_PREFIX = "https://developer.openactive.io/data-model/types/";

const { getModels, getEnums, getMetaData } = require('@openactive/data-models');
var fs = require('fs');
var fsExtra = require('fs-extra');
var request = require('sync-request');
var path = require('path');

var EXTENSIONS = {
    "beta": {
        "url": "https://www.openactive.io/ns-beta/beta.jsonld",
        "heading": "OpenActive Beta Extension properties",
        "description": "These properties are defined in the [OpenActive Beta Extension](https://openactive.io/ns-beta). The OpenActive Beta Extension is defined as a convenience to help document properties that are in active testing and review by the community. Publishers should not assume that properties in the beta namespace will either be added to the core specification or be included in the namespace over the long term."
    }
};

generateModelClassFiles(DATA_MODEL_OUTPUT_DIR, EXTENSIONS);

function generateModelClassFiles(dataModelDirectory, extensions) {
    // Empty output directories
    fsExtra.emptyDirSync(DATA_MODEL_OUTPUT_DIR + 'models');
    fsExtra.emptyDirSync(DATA_MODEL_OUTPUT_DIR + 'enums');

    // Returns the latest version of the models map
    const models = getModels();
    const enumMap = getEnums();
    const namespaces = getMetaData().namespaces;

    // Add all extensions and namespaces first, in case they reference each other
    Object.keys(extensions).forEach(function (prefix) {
        var extension = getExtension(extensions[prefix].url);
        if (!extension) throw "Error loading extension: " + prefix;

        extensions[prefix].graph = extension["@graph"];
        extension["@context"].forEach(function (context) {
            if (typeof context === 'object') {
                Object.assign(namespaces, context);
            }
        });
    });

    Object.keys(extensions).forEach(function (prefix) {
        var extension = extensions[prefix];
        augmentWithExtension(extension.graph, models, extension.url, prefix, namespaces);
        augmentEnumsWithExtension(extension.graph, enumMap, extension.url, prefix, namespaces);
    });

    Object.keys(models).forEach(function (typeName) {
        var model = models[typeName];
        if (typeName != "undefined") { //ignores "model_list.json" (which appears to be ignored everywhere else)

            var pageName = 'models/' + getPropNameFromFQP(model.type) + ".cs";
            var pageContent = createModelFile(model, models, extensions, enumMap);

            console.log("NAME: " + pageName);
            console.log(pageContent);

            fs.writeFile(DATA_MODEL_OUTPUT_DIR + pageName, pageContent, function (err) {
                if (err) {
                    return console.log(err);
                }

                console.log("FILE SAVED: " + pageName);
            });
        }
    });

    // Converts the enum map into an array for ease of use
    Object.keys(enumMap).filter(typeName => !includedInSchema(enumMap[typeName].namespace)).forEach(function (typeName) {
        var thisEnum = enumMap[typeName];

        var pageName = "enums/" + typeName + ".cs";
        var pageContent = createEnumFile(typeName, thisEnum);

        console.log("NAME: " + pageName);
        console.log(pageContent);

        fs.writeFile(DATA_MODEL_OUTPUT_DIR + pageName, pageContent, function (err) {
            if (err) {
                return console.log(err);
            }

            console.log("FILE SAVED: " + pageName);
        });
    });
}

function augmentWithExtension(extModelGraph, models, extensionUrl, extensionPrefix, namespaces) {
    // Add classes first
    extModelGraph.forEach(function (node) {
        if (node.type === 'Class' && Array.isArray(node.subClassOf) && node.subClassOf[0] != "schema:Enumeration") {
            // Only include subclasses for either OA or schema.org classes
            var subClasses = node.subClassOf.filter(prop => models[getPropNameFromFQP(prop)] || includedInSchema(prop));
            
            var model = subClasses.length > 0 ? {
                "type": node.id,
                // Include first relevant subClass in list (note this does not currently support multiple inheritance), which is discouraged in OA modelling anyway
                "subClassOf": models[getPropNameFromFQP(subClasses[0])] ? "#" + getPropNameFromFQP(subClasses[0]) : expandPrefix(subClasses[0], false, namespaces)
            } :
            {
                "type": node.id
            };

            models[getPropNameFromFQP(node.id)] = model;
        }
    });

    // Add properties to classes
    extModelGraph.forEach(function (node) {
        if (node.type === 'Property') {
            var field = {
                "fieldName": getPropNameFromFQP(node.id),
                "alternativeTypes": node.rangeIncludes.map(type => expandPrefix(type, node.isArray, namespaces)),
                "description": [
                    node.comment + (node.githubIssue ? '\n\nIf you are using this property, please join the discussion at proposal ' + renderGitHubIssueLink(node.githubIssue) + '.' : '')
                ],
                "example": node.example,
                "extensionPrefix": extensionPrefix
            };
            node.domainIncludes.forEach(function (prop) {
                var model = models[getPropNameFromFQP(prop)];
                if (model) {
                    model.extensionFields = model.extensionFields || [];
                    model.fields = model.fields || {};
                    model.extensionFields.push(field.fieldName);
                    model.fields[field.fieldName] = field;
                }
            });
        }
    });
}

function augmentEnumsWithExtension(extModelGraph, enumMap, extensionUrl, extensionPrefix, namespaces) {
    extModelGraph.forEach(function (node) {
        if (node.type === 'Class' && Array.isArray(node.subClassOf) && node.subClassOf[0] == "schema:Enumeration") {
            enumMap[node.label] = {
                "namespace": namespaces[extensionPrefix],
                "comment": node.comment,
                "values": extModelGraph.filter(n => n.type == node.id).map(n => n.label),
                "extensionPrefix": extensionPrefix
            };
        }
    });
}

function expandPrefix(prop, isArray, namespaces) {
    if (prop.lastIndexOf(":") > -1) {
        var propNs = prop.substring(0, prop.indexOf(":"));
        var propName = prop.substring(prop.indexOf(":") + 1);
        if (namespaces[propNs]) {
            if (propNs === "oa") {
                return (isArray ? "ArrayOf#" : "#") + propName;
            } else {
                return (isArray ? "ArrayOf#" : "") + namespaces[propNs] + propName;
            }
        } else {
            throw "Namespace not found for '" + prop + "'";
        }
    } else return prop;
}

function renderGitHubIssueLink(url) {
    var splitUrl = url.split("/");
    var issueNumber = splitUrl[splitUrl.length - 1];
    return "[#" + issueNumber + "](" + url + ")";
}

function getExtension(extensionUrl) {
    var response = request('GET', extensionUrl, { accept: 'application/ld+json' });
    if (response && response.statusCode == 200) {
        var body = JSON.parse(response.body);
        return body["@graph"] && body["@context"] ? body : undefined;
    } else {
        return undefined;
    }
}

function getParentModel(model, models) {
    if (model.subClassOf && model.subClassOf.indexOf("#") == 0) {
        return models[model.subClassOf.substring(1)];
    } else {
        return false;
    }
}

function getPropertyWithInheritance(prop, model, models) {
    if (model[prop]) return model[prop];

    var parentModel = getParentModel(model, models);
    if (parentModel) {
        return getPropertyWithInheritance(prop, parentModel, models);
    }

    return null;
}

function getMergedPropertyWithInheritance(prop, model, models) {
    var thisProp = model[prop] || [];
    var parentModel = getParentModel(model, models);
    if (parentModel) {
        return thisProp.concat(getMergedPropertyWithInheritance(prop, parentModel, models));
    } else {
        return thisProp;
    }
}

function obsoleteNotInSpecFields(model, models) {
    var augFields = Object.assign({}, model.fields);

    var parentModel = getParentModel(model, models);
    if (model.notInSpec && model.notInSpec.length > 0) model.notInSpec.forEach(function (field) {
        if (parentModel && parentModel.fields[field]) {
            if (getPropNameFromFQP(model.type).toLowerCase() !== field.toLowerCase()) { // Cannot have property with same name as type, so do not disinherit here
                augFields[field] = Object.assign({}, parentModel.fields[field]);
                augFields[field].obsolete = true;
            }
        } else {
            throw new Error('notInSpec field "' + field + '" not found in parent for model "' + model.type + '"');
        }
    });

    Object.keys(augFields).forEach(function (field) {
        var thisField = augFields[field];

        if ((thisField.sameAs && includedInSchema(thisField.sameAs)) ||
            (!thisField.sameAs && model.derivedFrom && includedInSchema(model.derivedFrom) ) ) {
            thisField.derivedFromSchema = true;
        }

        if (parentModel && parentModel.fields[field]) {
            thisField.override = true;
        }
    });

    return augFields;
}



function calculateInherits(subClassOf, derivedFrom, model) {
    // Prioritise subClassOf over derivedFrom
    if (subClassOf) {
        var subClassOfName = convertToCamelCase(getPropNameFromFQP(subClassOf));
        if (includedInSchema(subClassOf)) {
            return `Schema.NET.${subClassOfName}`;
        } else {
            return `${subClassOfName}`;
        }
    } else if (derivedFrom) {
        var derivedFromName = convertToCamelCase(getPropNameFromFQP(derivedFrom));
        if (includedInSchema(derivedFrom)) {
            return `Schema.NET.${derivedFromName}`;
        } else {
            // Note if derived from is outside of schema.org there won't be a base class, but it will still be JSON-LD
            return `Schema.NET.JsonLdObject`;
        }
    } else {
        // In the model everything is one or the other (at a minimum must inherit https://schema.org/Thing)
        throw new Error('No base class specified for: ' + model.type);
    }
}

function compareFields(xField, yField) {
    var x = xField.fieldName.toLowerCase();
    var y = yField.fieldName.toLowerCase();

    const knownPropertyNameOrders = {
        "context": 0,
        "type": 1,
        "id": 2,
        "identifier": 3,
        "title": 4,
        "name": 5,
        "description": 6
    }

    function compare(nameA, nameB) {
        if (nameA < nameB) {
            return -1;
        }
        if (nameA > nameB) {
            return 1;
        }

        // names must be equal
        return 0;
    }

    if (x === "enddate") {
        x = "startdate1";
    }
    else if (y === "enddate") {
        y = "startdate1";
    }

    var isXKnown = knownPropertyNameOrders.hasOwnProperty(x);
    var isYKnown = knownPropertyNameOrders.hasOwnProperty(y);
    if (isXKnown && isYKnown) {
        var xIndex = knownPropertyNameOrders[x];
        var yIndex = knownPropertyNameOrders[y];
        return compare(xIndex, yIndex);
    }
    else if (isXKnown) {
        return -1;
    }
    else if (isYKnown) {
        return 1;
    }
    else if (xField.extensionPrefix) {
        return 1;
    }
    else if (yField.extensionPrefix) {
        return -1;
    }

    return compare(x, y);
}

function createModelFile(model, models, extensions, enumMap) {
    var fullFields = obsoleteNotInSpecFields(model, models);
    var fullFieldsList = Object.values(fullFields).sort(compareFields).map((field, index) => { field.order = index + 6; return field; });
    var fullModel = createFullModel(fullFields, model, models);
    var derivedFrom = getPropertyWithInheritance("derivedFrom", model, models);
    var derivedFromName = convertToCamelCase(getPropNameFromFQP(derivedFrom));

    var inherits = calculateInherits(model.subClassOf, derivedFrom, model);

    // Note hasBaseClass is used here to ensure that assumptions about schema.org fields requiring overrides are not applied if the base class doesn't exist in the model
    var hasBaseClass = inherits != "Schema.NET.JsonLdObject";

    return `
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// ${getPropNameFromFQP(model.type) != model.type ? `[NOTICE: This is a beta class, and is highly likely to change in future versions of this library.]. ` : ""}${createCommentFromDescription(model.description).replace(/\n/g,'\n    /// ')}
    /// ${derivedFrom ? `This type is derived from [` + derivedFromName + `](` + derivedFrom + `)` + (derivedFrom.indexOf("schema.org") > -1 ? ", which means that any of this type's properties within schema.org may also be used. Note however the properties on this page must be used in preference if a relevant property is available" : "") + "." : ""}
    /// </summary>
    [DataContract]
    public partial class ${convertToCamelCase(getPropNameFromFQP(model.type))} : ${inherits}
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "${model.type}";

        ${createTableFromFieldList(fullFieldsList, models, enumMap, hasBaseClass)}
    }
}
`;

}

function createEnumFile(typeName, thisEnum) {
    var betaWarning = thisEnum.extensionPrefix == 'beta' ? "[NOTICE: This is a beta enumeration, and is highly likely to change in future versions of this library.] \n" : "";
    return `
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    /// <summary>
    /// ${(betaWarning + (thisEnum.comment || '')).replace(/\n/g, '\n    /// ')}
    /// </summary>
    public enum  ${typeName}
    {
        ${thisEnum.values.map(value => createEnumValue(value, thisEnum)).join(',')}
    }
}
`;

}

function createEnumValue(value, thisEnum) {
    
    return `
        [EnumMember(Value = "${thisEnum.namespace + value}")]
        ${value}`;
}


function createCommentFromDescription(description) {
    if (description === null || description === undefined) return "";
    if (description.sections) {
        return description.sections.map(section => (section.title && section.paragraphs ? `
## **` + section.title + `**
` + section.paragraphs.join("\n") : "")).join("\n\n") + "\n";
    } else {
        return "";
    }
}

function getDotNetType(fullyQualifiedType, enumMap, modelsMap, isExtension) {
    var baseType = getDotNetBaseType(fullyQualifiedType, enumMap, modelsMap, isExtension);
    if (isArray(fullyQualifiedType)) {
        // Remove ? from end of type if it's a list
        if (baseType.slice(-1) == '?') {
            return `List<${baseType.slice(0, -1)}>`;
        } else {
            return `List<${baseType}>`;
        }
    } else {
        return baseType;
    }
}

function getDotNetBaseType(prefixedTypeName, enumMap, modelsMap, isExtension) {
    var typeName = getPropNameFromFQP(prefixedTypeName);
    switch (typeName) {
        case "Boolean":
            return "bool?";
        case "DateTime":
        case "Time":
            return "DateTimeOffset?";
        case "Integer":
            return "int?";
        case "Float":
            return "decimal?";
        case "Number":
            return "decimal?";
        case "Date": // TODO: Find better way of representing Date
        case "Text":
            return "string";
        case "Duration":
            return "TimeSpan?";
        case "URL":
        case "Property":
            return "Uri";
        default:
            if (enumMap[typeName]) {
                if (includedInSchema(enumMap[typeName].namespace)) {
                    return "Schema.NET." + convertToCamelCase(typeName) + "?";
                } else {
                    return convertToCamelCase(typeName) + "?";
                }
            }
            else if (modelsMap[typeName]) {
                return convertToCamelCase(typeName);
            } else if (isExtension) {
                // Extensions may reference schema.org, for which we have no reference here to confirm
                console.log("Extension referenced schema.org property: " + typeName);
                return "Schema.NET." + convertToCamelCase(typeName);
            } else {
                throw new Error('Unrecognised type or enum referenced: ' + typeName)
            }
    }
}

function createTableFromFieldList(fieldList, models, enumMap, hasBaseClass) {
    return fieldList.filter(field => field.fieldName != "type" && field.fieldName != "@context").map(field => createPropertyFromField(field, models, enumMap, hasBaseClass)).join('\n');
}

function renderJsonConverter(field, propertyType) {
    if (propertyType == 'TimeSpan?') {
        return `\n        [JsonConverter(typeof(OpenActiveTimeSpanToISO8601DurationValuesConverter))]`;
    } else if (field.requiredType == 'https://schema.org/Time') {
        return `\n        [JsonConverter(typeof(OpenActiveDateTimeOffsetToISO8601TimeValuesConverter))]`;
    } else if (propertyType.indexOf("Values<") > -1) {
        return `\n        [JsonConverter(typeof(ValuesConverter))]`;
    } else {
        return "";
    }
}

function createPropertyFromField(field, models, enumMap, hasBaseClass) {
    var memberName = field.extensionPrefix ? `${field.extensionPrefix}:${field.fieldName}` : field.fieldName;
    var isExtension = !!field.extensionPrefix;
    var isNew = field.derivedFromSchema; // Only need new if sameAs specified as it will be replacing a schema.org type
    var propertyName = convertToCamelCase(field.fieldName);
    var propertyType = createTypeString(field, models, enumMap, isExtension);
    var jsonConverter = renderJsonConverter(field, propertyType);
    return !field.obsolete ? `
        /// ${createDescriptionWithExample(field).replace(/\n/g, '\n        /// ')}
        [DataMember(Name = "${memberName}", EmitDefaultValue = false, Order = ${isExtension ? 1000 + field.order : field.order})]${jsonConverter}
        public ${!isExtension && hasBaseClass && (isNew || field.override) ? "new " : ""}virtual ${propertyType} ${propertyName} { get; set; }
` : `
        [Obsolete("This property is disinherited in this type, and must not be used.", true)]
        public override ${propertyType} ${propertyName} { get; set; }
`;
}

function createTypeString(field, models, enumMap, isExtension) {
    var types = []
        .concat(field.alternativeTypes)
        .concat(field.requiredType)
        .concat(field.alternativeModels)
        .concat(field.model)
        .filter(type => type !== undefined);

    var types = types.map(fullyQualifiedType => getDotNetType(fullyQualifiedType, enumMap, models, isExtension))

    if (types.length == 0) {
        throw new Error('No type found for field: ' + field.fieldName);
    }

    // OpenActive SingleValues not allow many of the same type, only allows one
    return types.length > 1 ? `SingleValues<${types.join(', ')}>` : types[0];
}

function isArray(prop) {
    return prop.indexOf("ArrayOf") == 0;
}

function getPropLinkFromFQP(prop) {
    if (prop.lastIndexOf("/") > -1) {
        return prop.replace("ArrayOf#", "");
    } else if (prop.lastIndexOf("#") > -1) {
        return DATA_MODEL_DOCS_URL_PREFIX + prop.substring(prop.lastIndexOf("#") + 1).toLowerCase();
    } else return "#";
}

function getPropNameFromFQP(prop) {
    if (prop === null || prop === undefined) return null;
    //Just the characters after the last /, # or :
    var match = prop.match(/[/#:]/g);
    var lastIndex = match === null ? -1 : prop.lastIndexOf(match[match.length - 1]);
    if (lastIndex > -1) {
        return prop.substring(lastIndex + 1);
    } else return prop;
}

function createDescriptionWithExample(field) {
    if (field.requiredContent) {
        return "Must always be present and set to " + renderCode(field.requiredContent, field.fieldName, field.requiredType);
    } else {
        var betaWarning = field.extensionPrefix == 'beta' ? "[NOTICE: This is a beta field, and is highly likely to change in future versions of this library.] \n" : "";
        return `<summary>\n${betaWarning}${field.description.join(" \n")}\n</summary>`
            + (field.example ? "\n<example>\n" + renderCode(field.example, field.fieldName, field.requiredType) + "\n</example>" : "");
    }
}

function renderCode(code, fieldName, requiredType) {
    if (typeof code === 'object') {
        return "<code>\n" + (fieldName ? `"` + fieldName + `": ` : "") + JSON.stringify(code, null, 2)+ "\n</code>";
    } else {
        var isNumber = requiredType && (requiredType.indexOf("Integer") > -1 || requiredType.indexOf("Float") > -1);
        return "<code>\n" + (fieldName ? `"` + fieldName + `": ` : "") + (isNumber ? code : `"` + code + `"`) + "\n</code>";
    }
}

function createFullModel(fields, partialModel, models) {
    // Ensure each input prop exists
    var model = {
        requiredFields: getPropertyWithInheritance("requiredFields", partialModel, models) || [],
        requiredOptions: getPropertyWithInheritance("requiredOptions", partialModel, models) || [],
        recommendedFields: getPropertyWithInheritance("recommendedFields", partialModel, models) || [],
        extensionFields: getMergedPropertyWithInheritance("extensionFields", partialModel, models) || []
    }
    // Get all options that are used in requiredOptions
    var optionSetFields = [];
    model.requiredOptions.forEach(function (requiredOption) {
        optionSetFields = optionSetFields.concat(requiredOption.options);
    });
    // Create map of all fields
    var optionalFieldsMap = Object.keys(fields).reduce(function (map, obj) {
        map[obj] = true;
        return map;
    }, {});
    // Set all known fields to false
    model.requiredFields.concat(model.recommendedFields).concat(model.extensionFields)
        .forEach(field => optionalFieldsMap[field] = false);
    // Create array of optional fields
    var optionalFields = Object.keys(optionalFieldsMap).filter(field => optionalFieldsMap[field]);

    return {
        requiredFields: sortWithIdAndTypeOnTop(model.requiredFields),
        recommendedFields: sortWithIdAndTypeOnTop(model.recommendedFields),
        optionalFields: sortWithIdAndTypeOnTop(optionalFields),
        extensionFields: sortWithIdAndTypeOnTop(model.extensionFields),
        requiredOptions: model.requiredOptions
    };
}

function sortWithIdAndTypeOnTop(arr) {
    var firstList = [];
    if (arr.includes("type")) firstList.push("type");
    if (arr.includes("id")) firstList.push("id");
    var remainingList = arr.filter(x => x != "id" && x != "type");
    return firstList.concat(remainingList.sort());
}

function convertToCamelCase(str) {
    if (str === null || str === undefined) return null;
    return str.charAt(0).toUpperCase() + str.slice(1)
}

function includedInSchema(url) {
    if (!url) return false;
    return url.indexOf("//schema.org") > -1 || url.indexOf("schema:") == 0;
}
