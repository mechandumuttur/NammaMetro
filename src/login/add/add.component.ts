import { Component } from '@angular/core';
import { ServiceService } from '../../service/service.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add.component.html',
  styleUrl: './add.component.css'
})
export class AddComponent {

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
