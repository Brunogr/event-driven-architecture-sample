import { CartelaModel } from "../models/cartela.model";
import { AppService } from "../app.service";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class CartelaService extends AppService<CartelaModel>{
    
    constructor(http: HttpClient) {
        super(http);
      }

    async gerarCartela(numeros : number[]) : Promise<CartelaModel>{
        var cartela = await this.postAsync("cartela", numeros);

        return <CartelaModel>cartela;
    }

    async gerarCartelaAutomatica() : Promise<CartelaModel>{
        var cartela = await this.postAsync("cartela/automatica", null);

        return <CartelaModel>cartela;
    } 

    async getCartelas() : Promise<CartelaModel[]>{
        var cartelas = await this.getAllAsync("cartela");

        return <CartelaModel[]>cartelas;
    }
}