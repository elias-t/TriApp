import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Globals } from '../globals';
import { Race } from '../models/race';
import { Athlete } from '../models/athlete';
import { Result } from '../models/result';

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

  getAthletes() {
    return this.http.get<any[]>(`${this.globals.baseURL}api/Triathlon/GetAthletes`);
  }

  getAthletesForRace(raceId: number) {
    return this.http.get<any[]>(`${this.globals.baseURL}api/Triathlon/GetAthletesForRace/${raceId}`);
  }

  getDistinctRaces() {
    return this.http.get<any[]>(`${this.globals.baseURL}api/Triathlon/GetDistinctRaces`);
  }

  getRaceById(id: number) {
    return this.http.get<any[]>(`${this.globals.baseURL}api/Triathlon/GetResultsByRaceId/${id}`);
  }

  addRace(race : Race) {
    const addRaceURL = `${this.globals.baseURL}api/Triathlon/AddRace`;
    const obj = race;
    return this.http.post(addRaceURL, obj);
  }

  updateRace(race: Race) {
    const updateRaceURL = `${this.globals.baseURL}api/Triathlon/UpdateRace`;
    const obj = race;
    return this.http.post(updateRaceURL, obj);
  }

  deleteRace(id: number) {
    const deleteRaceURL = `${this.globals.baseURL}api/Triathlon/DeleteRace/${id}`;
    return this.http.delete(deleteRaceURL);
  }

  addAthlete(athlete: Athlete, raceId: number) {
    const addAthleteURL = `${this.globals.baseURL}api/Triathlon/AddAthlete/${raceId}/${athlete.city}/${athlete.team}/${athlete.bib}`;
    const obj = athlete;
    return this.http.post(addAthleteURL, obj);
  }

  updateResult(result: Result): any {
    const updateResultURL = `${this.globals.baseURL}api/Triathlon/UpdateResult`;
    const obj = result;
    return this.http.post(updateResultURL, obj);
  }

  deleteResult(id: number) {
    const deleteResultURL = `${this.globals.baseURL}api/Triathlon/DeleteResult/${id}`;
    return this.http.delete(deleteResultURL);
  }
}
