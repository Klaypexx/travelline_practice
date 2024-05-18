"use strict";
import fs from 'fs';
type Compare = Record<string, CompareValues>;
type CompareValues = {
  type: `unchanged` | `new` | `changed` | `delete`,
  newValue?: JsonValue,
  oldValue?: JsonValue,
  children?: Compare
};

type JsonValue = string | number | boolean | undefined | JsonObject;

type JsonObject = {
  [key: string]: JsonValue;
};

const compareObjects = (oldObject: JsonObject, newObject: JsonObject): Compare  => {
  const keys: string[] = Array.from(new Set([...Object.keys(oldObject), ...Object.keys(newObject)]));

  return keys.reduce<Compare>((result, key) => {
    const oldObjVal = oldObject[key];
    const newObjVal = newObject[key];

    if (!(oldObject.hasOwnProperty(key))) {
      return {
        ...result,
        [key]: {
          type: 'new',
          newValue: newObjVal
        }
      }
    }

    if (!(newObject.hasOwnProperty(key))) {
      return {
        ...result,
        [key]: {
          type: 'delete',
          oldObject: oldObjVal
        }
      }
    }

    if (typeof oldObjVal === 'object' && typeof newObjVal === 'object') {
      return {
        ...result,
        [key]: {
          type: 'changed',
          children: compareObjects(oldObjVal as JsonObject, newObjVal as JsonObject)
        }
      }
    }

    return {
      ...result,
      [key]: {
        type: oldObjVal == newObjVal ? 'unchanged' : 'changed',
        oldValue: oldObjVal,
        newValue: newObjVal
      }
    }
  }, {})
}
export const compareJsons = async (oldJsonPath: string, newJsonPath: string) => {
  const oldData = JSON.parse(fs.readFileSync(oldJsonPath, 'utf8'));
  const newData = JSON.parse(fs.readFileSync(newJsonPath, 'utf8'));
  const jsonDifference = compareObjects(oldData, newData);
  console.log(JSON.stringify(jsonDifference, null, 2));
}