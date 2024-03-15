import ReactPaginate from 'react-paginate';

const Paginate: React.FC<paginateProps> = ({ pageCount, onPageChange })=>{
    console.log('Entrando a paginar');
    return (
        <ReactPaginate         
        previousLabel={'<<'}
        nextLabel={'>>'}
        breakLabel={'...'}
        pageCount={pageCount}
        marginPagesDisplayed={2}
        pageRangeDisplayed={5}
        onPageChange={onPageChange}
        containerClassName={'pagination justify-content-center'} // Clases de Bootstrap para centrar la paginación
        activeClassName={'active'}
        previousClassName={'page-item'}
        nextClassName={'page-item'}
        previousLinkClassName={'page-link'}
        nextLinkClassName={'page-link'}
        pageClassName={'page-item'}
        pageLinkClassName={'page-link'}
        />
      );}

      interface paginateProps {
        pageCount: number;
        onPageChange: (data: { selected: number }) => void;
      }

      export default Paginate;