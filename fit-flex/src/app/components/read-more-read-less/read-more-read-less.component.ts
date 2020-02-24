import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-read-more-read-less',
  templateUrl: './read-more-read-less.component.html',
  styleUrls: ['./read-more-read-less.component.css']
})
export class ReadMoreReadLessComponent implements OnInit {

  private readonly readLessCount = 144;
  private readonly readLessLinkText = 'Lees minder';
  private readonly readMoreLinkText = 'Lees meer';

  private collapsed: boolean;
  @Input() text: string;

  enabled: boolean;
  textToDisplay: string;
  linkText: string;

  constructor() { }

  ngOnInit(): void {
    this.enabled = this.text.length > this.readLessCount;
    if (this.enabled) {
      this.collapsed = true;
      this.showLess();
    } else {
      this.textToDisplay = this.text;
    }
  }

  onToggle() {
    if (this.collapsed) {
      this.showMore();
    } else {
      this.showLess();
    }
    this.collapsed = !this.collapsed;
  }

  private showLess() {
    this.textToDisplay = this.text.substring(0, this.readLessCount) + ' ...';
    this.linkText = this.readMoreLinkText;
  }

  private showMore() {
    this.textToDisplay = this.text;
    this.linkText = this.readLessLinkText;
  }
}
