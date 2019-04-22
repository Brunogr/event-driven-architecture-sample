import { ProdutoModel } from './../../models/produto.model';
import { Component, Pipe, OnInit } from '@angular/core';
import { CarrinhoService } from '../../services/carrinho.service';
import { CarrinhoModel } from '../../models/carrinho.model';
import { Subscription } from 'rxjs/Subscription';
import { Observable } from 'rxjs';
import * as moment from 'moment';
import swal from 'sweetalert2';
import { ProdutoService } from '../../services/produto.service';
import { Jsonp } from '@angular/http';

@Component({
  selector: 'app-cartela',
  templateUrl: './carrinho.component.html',
  styleUrls: ['./carrinho.component.css']
})
export class CarrinhoComponent implements OnInit {

  constructor(private carrinhoService: CarrinhoService, 
    private produtoservice: ProdutoService) { }
  numeros : number[] = [null, null, null, null, null, null];
  carrinhos : CarrinhoModel[] = [];
  refresher : Subscription;
  produtos : ProdutoModel[] = [];

  ngOnInit() {

    this.produtoservice.getProdutos().then(p => this.produtos = p);

    this.refresher = Observable.timer(5000).repeat().subscribe(() => {
      this.carrinhoService.getCarrinho().then(c => {
        this.carrinhos = c;
      });
    });
  }

  async adicionarProduto(produto: ProdutoModel){
    await this.carrinhoService.adicionarAoCarrinho(produto);

    swal("Produto adicionado ao carrinho!");
  }

  formatarProduto() : string{

    return JSON.stringify(this.carrinhos[0].produtos);
  }

  gerarCartelaAutomatica(){
    this.carrinhoService.gerarCartelaAutomatica().then(c => swal("Cartela criada com sucesso!"));
  }

}
