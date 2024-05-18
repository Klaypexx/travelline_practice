import { readFile } from "fs/promises";
import { parse, HTMLElement } from 'node-html-parser';

const parseHtmlFile = async (path: string): Promise<string> => {
  const data = await readFile(path, 'utf-8');
  return data;
};

const performDataToLink = (data: string): string[] => {
  const links: HTMLElement[] = parse(data).querySelectorAll('[href], [src]');

  const uniqueLinks = Array.from(links).reduce<string[]>((acc, link) => {
    const href = link.getAttribute('href') || link.getAttribute('src');
    if (href && !acc.includes(href)) {
        acc.push(href);
    };

    return acc;
  }, []);

return uniqueLinks;  
}

export const parseHtml = async (path: string) => {
  const data: string = await parseHtmlFile(path);
  const linkData: string[] = performDataToLink(data);
  console.log(linkData);
} 