import { Component, OnInit } from '@angular/core';
import {EventService} from '../../event.service';
import {Event} from '../../event';

@Component({
  selector: 'app-week',
  templateUrl: './week.component.html',
  styleUrls: ['./week.component.css']
})
export class WeekComponent implements OnInit {
  results: Array<Event>;
  title: "Events for the week of";

  constructor(private eventService: EventService) {}
  
  ngOnInit() {
  	this.getAllEvents();
  }

  getAllEvents(): void {
    // this.eventService.getAll().subscribe(
    //       data => { this.results = data; },
    //       error => console.log(error)
    //       );

    this.eventService.getAll()
      .then(data => this.results = data);
     
  }

  previous(){
  	console.log("previous clicked!");
  }

  next(){
  	console.log("next clicked!");
  }

}
