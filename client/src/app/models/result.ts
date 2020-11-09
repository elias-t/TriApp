import { Athlete } from './athlete';
import { Race } from './race';

export class Result {
  resultId: number;
  timeSwim: string;
  timeT1: string;
  timeBike: string;
  timeT2: string;
  timeRun: string;
  timeTotal: string;
  resultAthlete: Athlete;
  resultRace: Race;
}
