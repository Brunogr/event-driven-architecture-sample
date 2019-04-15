import { Component, Pipe, OnInit } from '@angular/core';
import { CartelaService } from '../../services/cartela.service';
import { CartelaModel } from '../../models/cartela.model';
import { Subscription } from 'rxjs/Subscription';
import { Observable } from 'rxjs';
import * as moment from 'moment';
import swal from 'sweetalert2';

@Component({
  selector: 'app-cartela',
  templateUrl: './cartela.component.html',
  styleUrls: ['./cartela.component.css']
})
export class CartelaComponent implements OnInit {

  constructor(private cartelaService: CartelaService) { }
  numeros : number[] = [null, null, null, null, null, null];
  cartelas : CartelaModel[] = [];
  refresher : Subscription;
  transform(data: any, args?: any): any {
    let d = new Date(data)
    return moment(d).format('DD/MM/YYYY hh:mm')

  }
  ngOnInit() {

    this.refresher = Observable.timer(5000).repeat().subscribe(() => {
      this.cartelaService.getCartelas().then(c => {
        this.cartelas = c;
      });
    })

    
  }

  gerarCartela(){
    console.log(this.numeros);
    this.cartelaService.gerarCartela(this.numeros).then(c => swal("Cartela criada com sucesso!"));
  }

  gerarCartelaAutomatica(){
    this.cartelaService.gerarCartelaAutomatica().then(c => swal("Cartela criada com sucesso!"));
  }

}
