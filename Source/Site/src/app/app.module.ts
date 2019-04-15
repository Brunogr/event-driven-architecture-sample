import { AppRoutingModule } from './app.routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { CartelaComponent } from './components/cartela/cartela.component';
import { SorteioComponent } from './components/sorteio/sorteio.component';
import { CartelaService } from './services/cartela.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule} from '@angular/forms';
import { SorteioService } from './services/sorteio.service';
import { AppServiceInterceptor } from './interceptors/app.service.interceptor';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    CartelaComponent,
    SorteioComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    CartelaService,
    SorteioService,
    { provide: HTTP_INTERCEPTORS, useClass: AppServiceInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
