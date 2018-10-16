import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SupportUserListComponent } from './support-user-list.component';

describe('SupportUserListComponent', () => {
  let component: SupportUserListComponent;
  let fixture: ComponentFixture<SupportUserListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SupportUserListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SupportUserListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
