import { Component, OnInit, ViewChildren,QueryList,ContentChildren} from '@angular/core';
import {Event} from '../event';
import {EventService} from '../event.service';
import {WeekComponent} from './week/week.component'
import {AuthenticationService} from '../authentication.service'

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css'],
    
})
export class EventComponent implements OnInit {
  loggedIn = false;
  currentDate: Date = new Date();

  @ViewChildren(WeekComponent)
    viewChildren: QueryList<WeekComponent>;

  constructor(private eventService: EventService, private user: AuthenticationService) {}

  ngOnInit() {
    this.loggedIn = this.user.isLoggedIn();
    console.log(this.currentDate);
    // this.viewChildren.toArray().forEach((child) => child.currentDate = this.currentDate);
  }

  loadPrevWeek(){
    console.log("previous clicked");
    this.currentDate.setDate(this.currentDate.getDate() - 7);
    this.viewChildren.toArray().forEach((child) => child.setTime(this.currentDate));
    // this.viewChildren.toArray().forEach((child) => child.previous());
    this.viewChildren.toArray().forEach((child) => child.getAllEvents());
    
  }

  loadNextWeek(){
    console.log("previous clicked");
    this.currentDate.setDate(this.currentDate.getDate() + 7);
    this.viewChildren.toArray().forEach((child) => child.setTime(this.currentDate));

    // this.viewChildren.toArray().forEach((child) => child.next());
    this.viewChildren.toArray().forEach((child) => child.getAllEvents());
  }
}
