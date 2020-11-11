import { Athlete } from './athlete';
import { Race } from './race';

export class Result {
  resultId: number;
  timeSwimStr: string;
  timeT1Str: string;
  timeBikeStr: string;
  timeT2Str: string;
  timeRunStr: string;
  timeTotalStr: string;
  resultAthlete: Athlete;
  resultRace: Race;
}
