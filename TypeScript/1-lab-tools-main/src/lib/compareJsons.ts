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
  const allKeys: string[] = Array.from(new Set([...Object.keys(oldObject), ...Object.keys(newObject)]));

  return allKeys.reduce<Compare>((result, key) => {
    // console.log(key);
    const oldObjVal = oldObject[key];
    const newObjVal = newObject[key];

    if (oldObjVal != undefined && newObjVal != undefined) {
      console.log(oldObjVal);
      console.log(newObjVal);
    }
    return result;
  }, {})
}
export const compareJsons = async (oldJsonPath: string, newJsonPath: string) => {
  const oldData = JSON.parse(fs.readFileSync(oldJsonPath, 'utf8'));
  const newData = JSON.parse(fs.readFileSync(newJsonPath, 'utf8'));
  const jsonDifference = compareObjects(oldData, newData);
  console.log(jsonDifference);
}