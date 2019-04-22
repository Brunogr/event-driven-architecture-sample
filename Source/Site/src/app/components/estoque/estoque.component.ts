import swal from 'sweetalert2';
import { Component, OnInit } from '@angular/core';
import { EstoqueService } from '../../services/estoque.service';
import { EstoqueModel } from '../../models/estoque.model';
import { Subscription, Observable } from 'rxjs';

@Component({
  selector: 'app-sorteio',
  templateUrl: './estoque.component.html',
  styleUrls: ['./estoque.component.css']
})
export class EstoqueComponent implements OnInit {

  estoques : EstoqueModel[] = [];
  refresher : Subscription;
  
  constructor(private estoqueService : EstoqueService) { }

  ngOnInit() {
    this.refresher = Observable.timer(5000).repeat().subscribe(() => {
      this.estoqueService.getEstoques().then(c => {
        this.estoques = c;
      });
    });
  }
}
