import { Routes } from '@angular/router';
import { HomeComponent } from '../Components/home/home.component';
import { AboutComponent } from '../Components/about/about.component';
import { ContactusComponent } from '../Components/contactus/contactus.component';
import { RegisterComponent } from '../Components/register/register.component';
import { MapComponent } from '../Components/map/map.component';
import { TimetableComponent } from '../Components/timetable/timetable.component';
import { LoginComponent } from '../login/login/login.component';
import { ListofpassengersComponent } from '../login/listofpassengers/listofpassengers.component';
import { SearchComponent } from '../login/search/search.component';
import { DeleteComponent } from '../login/delete/delete.component';
import { AddComponent } from '../login/add/add.component';
import { UpdateComponent } from '../login/update/update.component';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full'},
    {path:'home',component:HomeComponent},
    {path:'about',component:AboutComponent},
    {path:'contactus',component:ContactusComponent},
    {path:'login',component:LoginComponent, children:[
        {path:'listofpassengers',component:ListofpassengersComponent},
        {path:'search',component:SearchComponent},
        {path:'delete',component:DeleteComponent},
        {path:'add',component:AddComponent},
        {path:'update',component:UpdateComponent}
    ]},
    {path:'register',component:RegisterComponent},
    {path:'map',component:MapComponent},
    {path:'timetable',component:TimetableComponent},
];
