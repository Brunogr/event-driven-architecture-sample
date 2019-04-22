import { EstoqueModel } from '../models/estoque.model';
import { AppService } from "../app.service";
import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ProdutoModel } from '../models/produto.model';

@Injectable()
export class ProdutoService extends AppService<ProdutoModel>{
    
    constructor(http: HttpClient) {
        super(http);
        this.domain = "https://localhost:44374/"
      }

    async getProdutos() : Promise<ProdutoModel[]>{
        var produtos = await this.getAllAsync("produto");

        return <ProdutoModel[]>produtos;
    }
} 