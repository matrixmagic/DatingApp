import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  values: any = {};
  constructor(private http: HttpClient) { }

  ngOnInit() {

  }
  registerToggle() {

    this.registerMode = true ;
  }
  /*
  getValues() {
    console.log('hello world 1');
    this.http.get('http://localhost:5000/api/values').subscribe(response => {
 this.values = response;


    } , error =>  {
      console.log('hello world');
      console.log(error);

    } );
  }
  */
  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }

}
