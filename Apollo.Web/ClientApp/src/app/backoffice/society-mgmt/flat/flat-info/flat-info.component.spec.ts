import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlatInfoComponent } from './flat-info.component';

describe('FlatInfoComponent', () => {
  let component: FlatInfoComponent;
  let fixture: ComponentFixture<FlatInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlatInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlatInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
