import { ProdutoModel } from './../models/produto.model';
import { CarrinhoModel } from "../models/carrinho.model";
import { AppService } from "../app.service";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class CarrinhoService extends AppService<CarrinhoModel>{
    
    constructor(http: HttpClient) {
        super(http);
        this.domain = "https://localhost:44394/";
      }

    async adicionarAoCarrinho(produto : ProdutoModel) : Promise<CarrinhoModel>{
        var cartela = await this.postAsync("carrinho", {
            idProduto : produto.id,
            nomeProduto : produto.nome,
            valorProduto : produto.valor,
            nomeComprador :"Bruno"
        });

        return <CarrinhoModel>cartela;
    }

    async gerarCartelaAutomatica() : Promise<CarrinhoModel>{
        var cartela = await this.postAsync("cartela/automatica", null);

        return <CarrinhoModel>cartela;
    } 

    async getCarrinho() : Promise<CarrinhoModel[]>{
        var cartelas = await this.getAllAsync("carrinho");

        return <CarrinhoModel[]>cartelas;
    }
}