import { Component, OnInit, Injectable } from '@angular/core';

import { Format } from '../models/format';

@Injectable({
  providedIn: 'root'
})

@Component({
  selector: 'app-triathloncalculator',
  templateUrl: './triathloncalculator.component.html',
  styleUrls: ['./triathloncalculator.component.css']
})

export class TriathloncalculatorComponent implements OnInit{
  
  ngOnInit(){
  }

  constructor() {
  
  }

  public totalTime: number = 0.0;
  public totalSwim: number = 0.0;
  public totalT1: number = 0.0;
  public totalBike: number = 0.0;
  public totalT2: number = 0.0;
  public totalRun: number = 0.0;
  public totalTimeString: string = "";
  public selectRace = "Select event";
  public swim: number = 0;
  public inputSwim: string = "";
  public inputT1: string = "";
  public inputBike: string = "";
  public inputT2: string = "";
  public inputRun: string = "";
  public races: Format[] = [
    { formatId:1, name: "Sprint", swim: 0.75, bike: 20.0, run: 5.0 },
    { formatId:2, name: "Olympic", swim: 1.6, bike: 40.0, run: 10.0 },
    { formatId:3, name: "70.3", swim: 1.8, bike: 90.0, run: 21.1 },
    { formatId:4, name: "140.6", swim: 3.8, bike: 180.0, run: 42.2 }
  ];
  public selectedRace: Format[];

  public selectChangeHandler(event: any) {
    //update the ui
    this.selectRace = event.target.value;
    this.selectedRace = (this.races.filter((item) => item.name == this.selectRace)) as any[];
    
  }

  public timeCounter() {

    //var swimTime = angular.element('#swim').val()
    //var swimtime = $scope.swim;
    //var array = this.inputSwim.split(':')[0];
    //totalTime in seconds.
    this.totalSwim = this.selectedRace[0].swim * 10 * (parseInt(this.inputSwim.split(':')[0]) * 60 + parseInt(this.inputSwim.split(':')[1]));
    this.totalT1 = (parseInt(this.inputT1.split(':')[0]) * 60 + parseInt(this.inputT1.split(':')[1]));
    this.totalBike = (this.selectedRace[0].bike * 1.00 / parseFloat(this.inputBike) * 3600.00);
    this.totalT2 = (parseInt(this.inputT2.split(':')[0]) * 60 + parseInt(this.inputT2.split(':')[1]));
    this.totalRun = (this.selectedRace[0].run * (parseInt(this.inputRun.split(':')[0]) * 60 + parseInt(this.inputRun.split(':')[1])));
    this.totalTime = this.totalSwim + this.totalT1 + this.totalBike + this.totalT2 + this.totalRun;
    var minutes = this.totalTime / 60;
    var fseconds = Math.floor(this.totalTime % 60);
    var fhours = Math.floor(minutes / 60);
    var fminutes = Math.floor(minutes % 60);
    this.totalTimeString = fhours + " hours, " + fminutes + " minutes, " + fseconds + " seconds";
  }

  public calculatePace(discipline: string, time: string, distance: number): string {
    //distance in km
    var result = "";
    if (discipline == "swim") {
      var seconds = (parseInt(time.split(':')[0]) * 3600 + parseInt(time.split(':')[1]) * 60 + parseInt(time.split(':')[2])) / (distance * 10);
      result = "" + ((Math.trunc(seconds / 60) < 10) ? "0" + Math.trunc(seconds / 60) : Math.trunc(seconds / 60)) + ":" + "" + (seconds % 60 < 10 ? "0" + (seconds % 60).toFixed(0) : (seconds % 60).toFixed(0));
    }
    else if (discipline == "bike") {
      var speed = ((distance * 3600) / ((parseInt(time.split(':')[0]) * 3600 + parseInt(time.split(':')[1]) * 60 + parseInt(time.split(':')[2])))).toFixed(2);
      result = "" + speed;
    }
    else if (discipline == "run") {
      seconds = ((parseInt(time.split(':')[0]) * 3600 + parseInt(time.split(':')[1]) * 60 + parseInt(time.split(':')[2]))) / (distance);
      result = "" + (Math.trunc(seconds / 60) < 10 ? "0" + Math.trunc(seconds / 60) : Math.trunc(seconds / 60)) + ":" + "" + (seconds % 60 < 10 ? "0" + (seconds % 60).toFixed(0) : (seconds % 60).toFixed(0));
    }
    return result;
  }

}
