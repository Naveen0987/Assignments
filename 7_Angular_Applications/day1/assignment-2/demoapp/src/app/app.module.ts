import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // Add this
import { AppComponent } from './app.component';
// ...
@NgModule({
  declarations: [
    // ...
  ],
  imports: [
    BrowserModule,
    FormsModule, // Add this
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }