import { ContactInfoService } from './../../_services/contact-info-service';
import { Component } from '@angular/core';
import { ContactInfoDto } from '../../_models/contactInfoDto';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-contact-main',
  standalone: false,
  templateUrl: './contact-main.html',
  styleUrl: './contact-main.css',
})
export class ContactMain {

  contactInfos: ContactInfoDto[];


  constructor(private contactInfoService: ContactInfoService, private sanitizer: DomSanitizer){
    this.getContactInfos();
    window.scrollTo({ top: 0, behavior: 'smooth' });

  }


  getContactInfos(){
    this.contactInfoService.getAll().subscribe({
      next: result=>this.contactInfos = result.data,
      error: result=>console.log(result.error)
    })
  }

  getSafeUrl(url: string) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }

}




