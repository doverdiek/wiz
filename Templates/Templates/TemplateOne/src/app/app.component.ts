import { Component, OnInit } from '@angular/core';
import { WebshopInformation } from './core/models/WebshopInformation';
import { WebshopInformationStore } from './core/stores/webshopInformationStore';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

webshopInformation: WebshopInformation = new WebshopInformation();


constructor(private webshopInformationStore: WebshopInformationStore)
{}


ngOnInit() {
  this.getAllProducts();
}

async getAllProducts()
{

}



}
