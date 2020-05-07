package com.gdu.letranbaosuong.dhpm11.mahoadongian.GiaiThuat.AES;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

import com.gdu.letranbaosuong.dhpm11.mahoadongian.GiaiThuat.AES.Matrix;

public class Keys {
    public List<Matrix> RoundKeys = new List<Matrix>() {
        @Override
        public int size() {
            return RoundKeys.size();
        }

        @Override
        public boolean isEmpty() {
            return RoundKeys.isEmpty();
        }

        @Override
        public boolean contains(@Nullable Object o) {
            return false;
        }

        @NonNull
        @Override
        public Iterator<Matrix> iterator() {
            return null;
        }

        @NonNull
        @Override
        public Object[] toArray() {
            return new Object[0];
        }

        @NonNull
        @Override
        public <T> T[] toArray(@NonNull T[] a) {
            return null;
        }

        @Override
        public boolean add(Matrix matrix) {
            return RoundKeys.add(matrix);
        }

        @Override
        public boolean remove(@Nullable Object o) {
            return false;
        }

        @Override
        public boolean containsAll(@NonNull Collection<?> c) {
            return false;
        }

        @Override
        public boolean addAll(@NonNull Collection<? extends Matrix> c) {
            return false;
        }

        @Override
        public boolean addAll(int index, @NonNull Collection<? extends Matrix> c) {
            return false;
        }

        @Override
        public boolean removeAll(@NonNull Collection<?> c) {
            return false;
        }

        @Override
        public boolean retainAll(@NonNull Collection<?> c) {
            return false;
        }

        @Override
        public void clear() {
            RoundKeys.clear();
        }

        @Override
        public Matrix get(int index) {
            return null;
        }

        @Override
        public Matrix set(int index, Matrix element) {
            return null;
        }

        @Override
        public void add(int index, Matrix element) {

        }

        @Override
        public Matrix remove(int index) {
            return null;
        }

        @Override
        public int indexOf(@Nullable Object o) {
            return 0;
        }

        @Override
        public int lastIndexOf(@Nullable Object o) {
            return 0;
        }

        @NonNull
        @Override
        public ListIterator<Matrix> listIterator() {
            return null;
        }

        @NonNull
        @Override
        public ListIterator<Matrix> listIterator(int index) {
            return null;
        }

        @NonNull
        @Override
        public List<Matrix> subList(int fromIndex, int toIndex) {
            return null;
        }
    };

    public Keys() {

    }

    public void setCipherKey(Matrix CipherKey) {
        if (RoundKeys.size() == 0) {
            this.RoundKeys.add(CipherKey);
        } else {
            RoundKeys.clear();
            RoundKeys.add(CipherKey);
        }
        RoundKeys.add(new Matrix(4, 4));
        RoundKeys.add(new Matrix(4, 4));
        RoundKeys.add(new Matrix(4, 4));
        RoundKeys.add(new Matrix(4, 4));
        RoundKeys.add(new Matrix(4, 4));
        RoundKeys.add(new Matrix(4, 4));
        RoundKeys.add(new Matrix(4, 4));
        RoundKeys.add(new Matrix(4, 4));
        RoundKeys.add(new Matrix(4, 4));
        RoundKeys.add(new Matrix(4, 4));
    }
}
