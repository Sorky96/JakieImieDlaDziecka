import { Sex } from "../Enums/Sex";
import { KidsNames } from "./KidsNames";

export interface NamesPerYear {
  year: Date;
  count: number;
  sexName: string;
  sex: Sex;
  name: string;
}
