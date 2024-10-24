import { NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ServiceService } from '../../service/service.service';

@Component({
  selector: 'app-update',
  standalone: true,
  imports: [FormsModule,NgFor],
  templateUrl: './update.component.html',
  styleUrl: './update.component.css'
})
export class UpdateComponent {

  restData:ServiceService;

  constructor(restDataref:ServiceService)
  {
    this.restData=restDataref;
  }

}
