import { Autoplay, Navigation, Pagination } from 'swiper/modules';
import { AuthService } from './../../_services/auth-service';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import Swiper from 'swiper';
import AOS from 'aos';
import { ContactInfoService } from '../../_services/contact-info-service';
import { ContactInfoDto } from '../../_models/contactInfoDto';
import { SocialService } from '../../_services/social-service';
import { SocialDto } from '../../_models/socialDto';

@Component({
  selector: 'main-layout',
  standalone: false,
  templateUrl: './main-layout.html',
  styleUrl: './main-layout.css',
})
export class MainLayout implements OnInit, AfterViewInit {
  constructor(private authService: AuthService,
    private contactInfoService: ContactInfoService,
    private socialService: SocialService
  ){}

  private swiper: Swiper | undefined;
  isMobileMenuOpen = false;
  contactInfos: ContactInfoDto[];
  socials: SocialDto[];

  ngOnInit() {
    this.getContactInfos();
    this.getSocials();

    // Initialize AOS
    AOS.init({
      duration: 1000,
      easing: 'ease-in-out',
      once: true,
      mirror: false
    });

    // Initialize Swiper
    this.swiper = new Swiper('.init-swiper', {
      modules: [Navigation, Pagination, Autoplay],
      loop: true,
      speed: 600,
      autoplay: {
        delay: 5000,
        disableOnInteraction: false
      },
      slidesPerView: 'auto',
      centeredSlides: true,
      pagination: {
        el: '.swiper-pagination',
        type: 'bullets',
        clickable: true
      },
      navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev'
      }
    });

    // Handle scroll top button
    window.addEventListener('scroll', () => {
      const scrollTop = document.querySelector('.scroll-top');
      if (scrollTop) {
        if (window.scrollY > 100) {
          scrollTop.classList.add('active');
        } else {
          scrollTop.classList.remove('active');
        }
      }
    });
  }

  ngAfterViewInit() {
    // Remove preloader after view is initialized
    const preloader = document.querySelector('#preloader');
    if (preloader) {
      preloader.remove();
    }
  }

  toggleMobileMenu() {
    this.isMobileMenuOpen = !this.isMobileMenuOpen;
    const navmenu = document.querySelector('#navmenu');
    if (navmenu) {
      if (this.isMobileMenuOpen) {
        navmenu.classList.add('mobile-nav-active');
      } else {
        navmenu.classList.remove('mobile-nav-active');
      }
    }
  }

  scrollToTop(event: Event) {
    event.preventDefault();
    window.scrollTo({
      top: 0,
      behavior: 'smooth'
    });
  }

  getFullName(){
    let decodedToken = this.authService.decodeToken();
    return decodedToken.fullName;
  }

  loggedIn(){
    return this.authService.loggedIn();
  }

  getContactInfos(){
    this.contactInfoService.getAll().subscribe({
      next: result=> this.contactInfos = result.data,
      error: result=> console.log(result.error)
    })
  }

  getSocials(){
    this.socialService.getAll().subscribe({
      next: result=> this.socials = result.data,
      error: result=> console.log(result.error)
    })
  }


}
