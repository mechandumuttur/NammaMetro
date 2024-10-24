import { NgClass, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { RouterModule, RouterOutlet } from '@angular/router';
import { ListofpassengersComponent } from '../listofpassengers/listofpassengers.component';
import { SearchComponent } from '../search/search.component';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [NgClass, FormsModule, NgIf, RouterOutlet,ListofpassengersComponent, RouterModule, SearchComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  result: string = "";
  isSuccess: boolean | null = null;
  LoginUser(LoginInfo:any){ 
    if(LoginInfo.value.username=="NammaMetro" && LoginInfo.value.password == "NammaMetro1234")
    {
      this.result = "Login Successful" + LoginInfo.value.username;
      this.isSuccess = true;
    }
    else{
      this.result ="Login Failed";
      this.isSuccess = false;
    }
    
  }

}
