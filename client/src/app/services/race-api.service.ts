import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Race } from '../models/race';
import { Athlete } from '../models/athlete';
import { Result } from '../models/result';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RaceApiService {
  private controllerEndpoint = `Triathlon`;
  constructor(private http: HttpClient) { }

  getFormats() {
    return this.http.get<any[]>(`${environment.endpoint}${this.controllerEndpoint}/GetFormats`);
  }

  getRaces() {
    return this.http.get<any[]>(`${environment.endpoint}${this.controllerEndpoint}/GetRaces`);
  }

  getAthletes() {
    return this.http.get<any[]>(`${environment.endpoint}${this.controllerEndpoint}/GetAthletes`);
  }

  getAthletesForRace(raceId: number) {
    return this.http.get<any[]>(`${environment.endpoint}${this.controllerEndpoint}/GetAthletesForRace/${raceId}`);
  }

  getDistinctRaces() {
    return this.http.get<any[]>(`${environment.endpoint}${this.controllerEndpoint}/GetDistinctRaces`);
  }

  getRaceById(id: number) {
    return this.http.get<any[]>(`${environment.endpoint}${this.controllerEndpoint}/GetResultsByRaceId/${id}`);
  }

  getResultsCountByRaceId(id: number){
    return this.http.get<any[]>(`${environment.endpoint}${this.controllerEndpoint}/GetResultsCountByRaceId/${id}`);
  }

  addRace(race : Race) {
    const addRaceURL = `${environment.endpoint}${this.controllerEndpoint}/AddRace`;
    const obj = race;
    return this.http.post(addRaceURL, obj);
  }

  updateRace(race: Race) {
    const updateRaceURL = `${environment.endpoint}${this.controllerEndpoint}/UpdateRace`;
    const obj = race;
    return this.http.post(updateRaceURL, obj);
  }

  deleteRace(id: number) {
    const deleteRaceURL = `${environment.endpoint}${this.controllerEndpoint}/DeleteRace/${id}`;
    return this.http.delete(deleteRaceURL);
  }

  addAthlete(athlete: Athlete, raceId: number) {
    const addAthleteURL = `${environment.endpoint}${this.controllerEndpoint}/AddAthlete/${raceId}/${athlete.city}/${athlete.team}/${athlete.bib}`;
    const obj = athlete;
    return this.http.post(addAthleteURL, obj);
  }

  updateResult(result: Result): any {
    const updateResultURL = `${environment.endpoint}${this.controllerEndpoint}/UpdateResult`;
    const obj = result;
    return this.http.post(updateResultURL, obj);
  }

  deleteResult(id: number) {
    const deleteResultURL = `${environment.endpoint}${this.controllerEndpoint}/DeleteResult/${id}`;
    return this.http.delete(deleteResultURL);
  }
}
