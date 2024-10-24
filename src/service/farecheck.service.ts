import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FarecheckService {

  constructor(_httpRef: HttpClient) {
    this._http = _httpRef;
   }
   private _http: HttpClient;

  calculateFare(fromStation: number, toStation: number): number {
    // Calculate number of stops
    const numberOfStops = Math.abs(toStation - fromStation);

    // Price per stop is 5 rupees
    const pricePerStop = 5;

    // Calculate total fare
    const fare = numberOfStops * pricePerStop;

    return fare;
  }

  // getPushDetails(addInfo: any) {
  //   const body = {
  //     source_stn: addInfo.value.fromStation,    // Source station from form
  //     destination_stn: addInfo.value.toStation, // Destination station from form
  //     const fare = this.calculateFare(fromStation, toStation);
    
  //   };

  // console.log(body.fare);


  //   this._http.post("https://localhost:7189/api/Bookings",JSON.stringify(body))
  //   .subscribe(response=>{ 
  //     console.log();
  //     console.log("Success", response);
  //     alert("Successfully added!");  // Alert message when the request is successful
  //   },
  //   error => {
  //     console.error("Error", error);  // Handle error response if needed
  //     alert("Failed to add. Please try again.");  // Optional: alert on failure
  //   }
  // );
  // }
  getPushDetails(addInfo: any) {
    const fromStation = addInfo.value.fromStation;    // Source station from form
    const toStation = addInfo.value.toStation;  
    const fare = addInfo.fare      // Destination station from form
  
    // Calculate fare using the function defined in the component
    // const fare = calculateFare();
  
    // Create the body object for the POST request
    const body = {
      source_stn: fromStation,
      destination_stn: toStation,
      fare: fare
    };
  
    console.log(body.fare);  // Log the calculated fare for debugging
  
    // Make the HTTP POST request
    this._http.post("https://localhost:7189/api/Bookings", JSON.stringify(body))
      .subscribe(response => {
        console.log("Success", response);
        alert("Successfully added!");  // Alert message when the request is successful
      },
      error => {
        console.error("Error", error);  // Handle error response if needed
        alert("Failed to add. Please try again.");  // Optional: alert on failure
      });
  }
  
  
}