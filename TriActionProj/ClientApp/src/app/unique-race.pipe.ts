import { Pipe, PipeTransform } from '@angular/core';
import { Race } from './models/race';

@Pipe({
  name: 'uniqueRace'
})
export class UniqueRacePipe implements PipeTransform {

  transform(races: Race[], args?: any): any {
    return races.map(c => c.name).filter((code, currentIndex, allCodes) => allCodes.indexOf(code) === currentIndex);
  }

}
