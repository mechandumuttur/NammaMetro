import { Component } from '@angular/core';
import { ServiceService } from '../../service/service.service';
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-listofpassengers',
  standalone: true,
  imports: [NgFor,NgIf],
  templateUrl: './listofpassengers.component.html',
  styleUrl: './listofpassengers.component.css'
})
export class ListofpassengersComponent {
  restData:ServiceService;

  constructor(restDataref:ServiceService)
  {
    this.restData=restDataref;
  }

}
