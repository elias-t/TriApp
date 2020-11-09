import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TriathloncalculatorComponent } from './triathloncalculator/triathloncalculator.component';
import { TriathlonresultsComponent } from './triathlonresults/triathlonresults.component';
import { ViewresultsComponent } from './viewresults/viewresults.component';

const routes: Routes = [
  { path: 'triathloncalculator', component: TriathloncalculatorComponent },
  { path: 'triathlonresults', component: TriathlonresultsComponent },
  { path: 'viewresults/:id', component: ViewresultsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
