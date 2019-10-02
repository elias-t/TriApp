import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Globals } from '../globals';
import { Race } from '../models/race';

@Injectable({
  providedIn: 'root'
})
export class RaceApiService {

  constructor(private http: HttpClient, private globals: Globals) { }

  getFormats() {
    return this.http.get<any[]>(`${this.globals.baseURL}api/Triathlon/GetFormats`);
  }

  getRaces() {
    return this.http.get<any[]>(`${this.globals.baseURL}api/Triathlon/GetRaces`);
  }

  getRaceById(id: number) {
    return this.http.get<any[]>(`${this.globals.baseURL}api/Triathlon/GetResultsByRaceId/${id}`);
  }

  addRace(race : Race) {
    const addRaceURL = `${this.globals.baseURL}api/Triathlon/AddRace`;
    //const obj = JSON.stringify({ race });
    const obj = race;
    return this.http.post(addRaceURL, obj);
  }
}
