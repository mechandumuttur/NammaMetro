import { NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { ServiceService } from '../../service/service.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, NgIf, NgFor],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {


  add(addInfo:any)
  {
    //u  can call a service method which can post a data to rest
    console.log(addInfo.value);
  }
  

  restData:ServiceService;

  constructor(restDataref:ServiceService)
  {
    this.restData=restDataref;
  }
  
  
}
