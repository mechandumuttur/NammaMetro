import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ServiceService } from '../../service/service.service';

@Component({
  selector: 'app-delete',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './delete.component.html',
  styleUrl: './delete.component.css'
})
export class DeleteComponent {

  delte(deleteInfo:any)
  {
    //u  can call a service method which can post a data to rest
    console.log(deleteInfo.value);
  }
  
  restData:ServiceService;

  constructor(restDataref:ServiceService)
  {
    this.restData=restDataref;
  }

}
