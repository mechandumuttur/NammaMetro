import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

// export class ServiceService {


//   _http:HttpClient;


 
    
//    getSearchDetails(searchdata:any){
//      this._http.get("https://localhost:7189/api/Passengers/"+searchdata.value.phoneNo)
//      .subscribe(response=>{ 
//        console.log("Success", response);
//       })   }



//   constructor(_httpRef:HttpClient) 
//   {
//     this._http=_httpRef;
//    }
// }


export class ServiceService {
  private _http: HttpClient;
  public storedata: any[] = []; // Add a property to hold the fetched data

  constructor(_httpRef: HttpClient) {
    this._http = _httpRef;
  }

  getdata:any;
   getuserDetails(){
     this._http.get("https://localhost:7189/api/Passengers/details")
     .subscribe((data)=>{ 
       this.getdata = data;
       console.log(data);
     })
   }

  getSearchDetails(searchdata: any) {
    this._http.get<any>("https://localhost:7189/api/Passengers/details/" + searchdata.value.phoneNo)
      .subscribe(response => {
        console.log("Success", response);
        this.storedata = [response]; // Store the response in getdata array
      }, error => {
        console.error("Error fetching data", error);
      });
  }

  getDeleteDetails(deletebook: any){
    this._http.delete("https://localhost:7189/api/Passengers/"+deletebook.value.phoneNo)
    .subscribe(response=>{ 
    console.log("Success", response);
    alert("Successfully deleted!"); 
  },
  error => {
   console.error("Error", error);  // Handle error response if needed
   alert("Failed to delete. Please try again.");  // Optional: alert on failure
 });
   
  }

  getAddDetails(addperson:any){
    this._http.post("https://localhost:7189/api/Passengers",addperson.value)
    .subscribe(response=>{ 
      console.log("Success", response);
      alert("Successfully added!"); 
   },
   error => {
    console.error("Error", error);  // Handle error response if needed
    alert("Failed to add. Please try again.");  // Optional: alert on failure
  }
   );
  }

  getUpdateDetails(updatedata:any){
    this._http.put("https://localhost:7189/api/Passengers/"+updatedata.value.phoneNo,updatedata.value)
    .subscribe(response=>{ 
      console.log("updated", response);
      alert("Successfully Updated!"); 
   },
   error => {
    console.error("Error", error);  // Handle error response if needed
    alert("Failed to update. Please try again.");  // Optional: alert on failure
  }
   );
   
}
// public carddata: any[] = [];
// getMetrocardDetails(metrodata: any) {
//   this._http.get<any>("https://localhost:7189/api/Passengers/details/" + metrodata.value.phoneNo)
//     .subscribe(response => {
//       console.log("Success", response);
//       this.carddata = [response]; // Store the response in getdata array
//     }, error => {
//       console.error("Error fetching data", error);
//     });
// }
}