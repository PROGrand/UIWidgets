namespace UIWidgets.foundation {
    public class AbstractNode {
        public int depth {
            get { return this._depth; }
        }

        public int _depth = 0;

        public void redepthChild(AbstractNode child) {
            if (child._depth <= this._depth) {
                child._depth = this._depth + 1;
                child.redepthChildren();
            }
        }

        public virtual void redepthChildren() {
        }

        public object owner {
            get { return this._owner; }
        }

        public object _owner;

        public bool attached {
            get { return this._owner != null; }
        }

        public virtual void attach(object owner) {
            this._owner = owner;
        }

        public virtual void detach() {
            this._owner = null;
        }

        public AbstractNode parent {
            get { return this._parent; }
        }

        public AbstractNode _parent;

        public virtual void adoptChild(AbstractNode child) {
            child._parent = this;
            if (this.attached) {
                child.attach(this._owner);
            }

            this.redepthChild(child);
        }

        public virtual void dropChild(AbstractNode child) {
            child._parent = null;
            if (this.attached) {
                child.detach();
            }
        }
    }
}