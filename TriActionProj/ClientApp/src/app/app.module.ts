import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TriathloncalculatorComponent } from './triathloncalculator/triathloncalculator.component';
import { FormsModule } from '@angular/forms';
import { NavmenuComponent } from './navmenu/navmenu.component';
import { TriathlonresultsComponent } from './triathlonresults/triathlonresults.component';
import { ViewresultsComponent } from './viewresults/viewresults.component';
import { RaceModalComponent } from './race-modal/race-modal.component';
import { UniqueRacePipe } from './unique-race.pipe';

@NgModule({
  declarations: [
    AppComponent,
    TriathloncalculatorComponent,
    NavmenuComponent,
    TriathlonresultsComponent,
    ViewresultsComponent,
    RaceModalComponent,
    UniqueRacePipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  entryComponents: [RaceModalComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
