import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { EventComponent } from './event/event.component';
import { LoginComponent } from './login/login.component';
import { AuthenticationService } from './authentication.service'
import { LoggedIn } from './logged-in.guard'
import { AlertModule } from 'ng2-bootstrap/ng2-bootstrap';
import { WeekComponent } from './event/week/week.component';

@NgModule({
  declarations: [
    AppComponent,
    EventComponent,
    LoginComponent,
    WeekComponent,
  ],
  imports: [
    AlertModule,
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent },
      { path: 'logout', component: LoginComponent },
      // { path: 'profile', component: EventComponent, canActivate: [LoggedIn] }
      { path: 'event', component: EventComponent }
      ])
  ],
  providers: [AuthenticationService, LoggedIn],
  bootstrap: [AppComponent]
})
export class AppModule { }
