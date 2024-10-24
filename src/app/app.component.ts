import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { HomeComponent } from '../Components/home/home.component';
import { AboutComponent } from '../Components/about/about.component';
import { ContactusComponent } from '../Components/contactus/contactus.component';
import { RegisterComponent } from '../Components/register/register.component';
import { ViewChild } from '@angular/core';
import { MapComponent } from '../Components/map/map.component';
import { TimetableComponent } from '../Components/timetable/timetable.component';
import { LoginComponent } from '../login/login/login.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,RouterModule,HomeComponent,AboutComponent,ContactusComponent,MapComponent,TimetableComponent,LoginComponent, RegisterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  @ViewChild('registerModal') registerModal!: RegisterComponent;

  
  title = 'MetroApp';
}
