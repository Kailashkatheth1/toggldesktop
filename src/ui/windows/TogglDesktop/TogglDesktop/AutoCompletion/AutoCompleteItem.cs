﻿using System.Collections.Generic;

namespace TogglDesktop.AutoCompletion
{
    abstract class AutoCompleteItem : AutoCompleteListItem
    {
        private bool selected;

        protected AutoCompleteItem(string text)
            : base(text)
        {
        }

        public bool Selected
        {
            get { return this.selected; }
            set
            {
                this.selected = value;
                if (value)
                {
                    this.select();
                }
                else
                {
                    this.unselect();
                }
            }
        }


        public override IEnumerable<AutoCompleteItem> Complete(string input)
        {
            this.Visible = this.Text.Contains(input);

            if (this.Visible)
            {
                yield return this;
            }
        }

        public override IEnumerable<AutoCompleteItem> CompleteAll()
        {
            this.Visible = true;
            yield return this;
        }

        protected abstract void select();
        protected abstract void unselect();

    }
}