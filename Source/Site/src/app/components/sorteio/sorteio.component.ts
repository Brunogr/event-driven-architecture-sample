import swal from 'sweetalert2';
import { Component, OnInit } from '@angular/core';
import { SorteioService } from '../../services/sorteio.service';
import { SorteioModel } from '../../models/sorteio.model';

@Component({
  selector: 'app-sorteio',
  templateUrl: './sorteio.component.html',
  styleUrls: ['./sorteio.component.css']
})
export class SorteioComponent implements OnInit {

  sorteio : SorteioModel = new SorteioModel();
  
  constructor(private sorteioService : SorteioService) { }

  ngOnInit() {
  }

  sortear(){
    this.sorteioService.sortear().then(s => {
      this.sorteio = s;
      swal("Sorteio efetuado! Verifique os números sorteados e os ganhadores.");
    });
  }

}
