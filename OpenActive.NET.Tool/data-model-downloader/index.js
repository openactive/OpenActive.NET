const { getModels, getEnums } = require('@openactive/data-models');
var fs = require('fs');
var request = require('sync-request');

const DATA_MODEL_LOCAL_DIR = "../data-model/";

downloadModels(DATA_MODEL_LOCAL_DIR);
downloadEnums(DATA_MODEL_LOCAL_DIR);

function downloadModels(dataModelDir) {
    // Returns the latest version of the models map
    const models = getModels();

    // Converts the map into an array as easier for .NET to parse
    var modelFileContent = [];
    Object.keys(models).forEach(function (typeName) {
        var model = models[typeName];
        if (typeName != "undefined") { //ignores "model_list.json" (which appears to be ignored everywhere else in the data model library)
            // Flatten map into array for .NET parsing
            modelFileContent.push({
                "type": model.type,
                "subClassOf": model.subClassOf,
                "derivedFrom": model.derivedFrom,
                // Remove example and simplify type fields
                "fields": Object.values(model.fields).map(field => ({
                    "fieldName": field.fieldName,
                    "sameAs": field.sameAs,
                    "types": [].concat(field.alternativeTypes).concat(field.requiredType).filter(type => type !== undefined),
                    "models": [].concat(field.alternativeModels).concat(field.model).filter(type => type !== undefined),
                    "requiredContent": field.requiredContent,
                    "description": field.description
                }))
            });
        }
    });

    // Writes the resulting array to a local file for .NET to read
    fs.writeFile(dataModelDir + "models.json", JSON.stringify(modelFileContent, null, 2), function (err) {
        if (err) {
            return console.log(err);
        }

        console.log("FILE SAVED: " + dataModelDir);
    });
}


function downloadEnums(dataModelDir) {
    // Returns the latest version of the models map
    const enums = getEnums();

    // Converts the map into an array as easier for .NET to parse
    var enumFileContent = [];
    Object.keys(enums).forEach(function (typeName) {
        var thisEnum = enums[typeName];
        // Flatten map into array for .NET parsing
        enumFileContent.push({
            "type": typeName,
            "namespace": thisEnum.namespace,
            "values": thisEnum.values
        });
    });

    // Writes the resulting array to a local file for .NET to read
    fs.writeFile(dataModelDir + "enums.json", JSON.stringify(enumFileContent, null, 2), function (err) {
        if (err) {
            return console.log(err);
        }

        console.log("FILE SAVED: " + dataModelDir);
    });
}