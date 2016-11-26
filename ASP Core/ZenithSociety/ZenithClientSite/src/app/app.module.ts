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

@NgModule({
  declarations: [
    AppComponent,
    EventComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([  
      { path: 'login', component: LoginComponent },
      // { path: 'profile', component: ProfileComponent, canActivate: [LoggedIn] }
      { path: 'event', component: EventComponent }
      ])
  ],
  providers: [AuthenticationService, LoggedIn],
  bootstrap: [AppComponent]
})
export class AppModule { }
