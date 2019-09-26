import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Globals {
  baseURL = document.getElementsByTagName('base')[0].href;
  
  isCurrentuserNameDismissed = false;
  isWeekBeginningDismissed = false;
}
