import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { BlogService } from '../../_services/blog-service';
import { ActivatedRoute, Router } from '@angular/router';
import { blogDto } from '../../_models/blog';
import { switchMap } from 'rxjs';

@Component({
  selector: 'app-blog-details',
  standalone: false,
  templateUrl: './blog-details.html',
  styleUrl: './blog-details.css',
})
export class BlogDetails implements OnInit{

  blog:blogDto;
  latestBlogs:blogDto[];

  constructor(private blogService: BlogService, private route: ActivatedRoute,private cdr: ChangeDetectorRef){
    this.getBlogById();
    this.getLatestBlogs();
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }
  ngOnInit(): void {
    this.getLatestBlogs();
    this.getBlogById();
  }


  getBlogById(){
    this.blogService.getBlogById(this.route.snapshot.params["id"]).subscribe({
      next: result=>this.blog = result.data,
    })
  }

  getLatestBlogs(){
    this.blogService.getLatest5Blogs().subscribe({
      next: result=> this.latestBlogs = result.data
    });
  }

}
