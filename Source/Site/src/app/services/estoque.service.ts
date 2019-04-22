import { AppService } from "../app.service";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { EstoqueModel } from "../models/estoque.model";

@Injectable()
export class EstoqueService extends AppService<EstoqueModel>{
    
    constructor(http: HttpClient) {
        super(http);
        this.domain = "https://localhost:44374/"
      }

    async getEstoques() : Promise<EstoqueModel[]>{
        var estoques = await this.getAllAsync("estoque");

        return <EstoqueModel[]>estoques;
    }
}