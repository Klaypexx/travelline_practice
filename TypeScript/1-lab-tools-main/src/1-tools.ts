import { program } from "commander";
import {parseHtml} from './lib/htmlParser.js';
import { compareJsons } from "./lib/compareJsons.js";

program
.command('html-resources')
.description('Helps to find sources in Html document')
.arguments('<path>')
.action((path: string) => parseHtml(path));

program
.command('json-diff')
.description('Helps to campare pair of json files')
.arguments('<oldJsonPath> <newJsonPath>')
.action((oldJsonPath: string, newJsonPath: string) => 
  compareJsons(oldJsonPath, newJsonPath));

program.parse(process.argv);