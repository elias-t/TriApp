import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Globals } from '../globals';

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
}
