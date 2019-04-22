import { AppRoutingModule } from './app.routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { CarrinhoComponent } from './components/carrinho/carrinho.component';
import { EstoqueComponent } from './components/estoque/estoque.component';
import { CarrinhoService } from './services/carrinho.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule} from '@angular/forms';
import { EstoqueService } from './services/estoque.service';
import { AppServiceInterceptor } from './interceptors/app.service.interceptor';
import { ProdutoService } from './services/produto.service';


@NgModule({
  declarations: [
    AppComponent, 
    HeaderComponent,
    HomeComponent,
    CarrinhoComponent,
    EstoqueComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    CarrinhoService,
    EstoqueService,
    ProdutoService,
    { provide: HTTP_INTERCEPTORS, useClass: AppServiceInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
