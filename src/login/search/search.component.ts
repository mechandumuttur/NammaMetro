import { Component } from '@angular/core';
import { FormsModule, NgModel } from '@angular/forms';
import { ServiceService } from '../../service/service.service';
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [FormsModule, NgFor, NgIf],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent {

  restData:ServiceService;

  constructor(restDataref:ServiceService)
  {
    this.restData=restDataref;
  }


  
}
