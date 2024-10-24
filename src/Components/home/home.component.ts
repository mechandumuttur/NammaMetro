import { NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FarecheckService } from '../../service/farecheck.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [FormsModule, NgIf],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  fromStation: number = 0;
  toStation: number = 0;
  fare: number = 0;
  ticketBooked: boolean = false;

  constructor(private farecheckService: FarecheckService) {}

  checkFare() {
    if (this.fromStation === this.toStation) {
      alert('Please choose different stations for "From Station" and "To Station".');
      return;
    }

    this.fare = this.farecheckService.calculateFare(this.fromStation, this.toStation);
    this.ticketBooked = false;  // Reset ticket booking status
  }

  bookTicket() {
    this.ticketBooked = true;  // Set to true to show the image
    alert('Successfully booked!');
  }
}
